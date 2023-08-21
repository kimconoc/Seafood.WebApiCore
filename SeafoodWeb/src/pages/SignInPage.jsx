import { Link, useNavigate } from "react-router-dom";
import LayoutAuthentication from "../layout/LayoutAuthentication";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import IconEyeToggle from "../components/icons/IconEyeToggle";
import { Input } from "../components/input";
import Label from "../components/label/Label";
import FromGroup from "../components/common/FromGroup";
import Button from "../components/button/Button";
import useToggleValue from "../hooks/useToggleValue";
import authService from "../services/auth.service";
import { toast } from "react-toastify";

const schema = yup.object({
  name: yup.string().required("This field is required"),
  password: yup
    .string()
    .required("This field is required")
    .min(8, "Password must be 8 character "),
});

const SignInPage = () => {
  const navigate = useNavigate();
  const {
    handleSubmit,
    control,
    formState: { errors ,isSubmitting},
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onSubmit",
  });
  const { value: showPassword, handleToggleValue: handleTogglePassword } =
    useToggleValue();
  const handleSignIn = async (values) => {
    try {
      await authService.userAPI
        .signIn(values.name, values.password)
        .then(() => {
          toast.success("Đăng nhập thành công");
          navigate("/home");
        });
    } catch (err) {
      toast.error("Username or password incorrect ");

      console.log(err);
    }
  };
  return (
    <LayoutAuthentication heading="Welcome Back!">
      <p className="mb-6 text-xs font-normal text-center lg:text-sm text-text3 lg:mb-8">
        Already have an account?{" "}
        <Link to="/sign-up" className="font-medium underline text-primary">
          Sign up
        </Link>
      </p>
      <button className="flex items-center justify-center w-full py-4 mb-5 text-base font-semibold border gap-x-3 border-strock rounded-xl text-text2 dark:text-white dark:border-darkStroke">
        <img srcSet="/google.png 2x" alt="icon-google" />
        <span>Sign up with google</span>
      </button>
      <form onSubmit={handleSubmit(handleSignIn)}>
        <FromGroup>
          <Label htmlFor="name">Username *</Label>
          <Input
            control={control}
            name="name"
            placeholder="Jhon Doe"
            error={errors.name?.message}
          ></Input>
        </FromGroup>
        <FromGroup>
          <Label htmlFor="password">Password *</Label>
          <Input
            control={control}
            name="password"
            type={`${showPassword ? "text" : "password"}`}
            placeholder="Enter Password"
            error={errors.password?.message}
          >
            <IconEyeToggle
              open={showPassword}
              onClick={handleTogglePassword}
            ></IconEyeToggle>
          </Input>
        </FromGroup>
        <FromGroup>
          <div className="text-right">
            <span className="inline-block text-sm font-medium text-primary">
              Forgot password
            </span>
          </div>
        </FromGroup>
        <Button className="w-full" kind="primary" type="submit" isLoading={isSubmitting}>
          Sign in
        </Button>
      </form>
    </LayoutAuthentication>
  );
};

export default SignInPage;
