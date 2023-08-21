import { Link, useNavigate } from "react-router-dom";
import LayoutAuthentication from "../layout/LayoutAuthentication";
import Label from "../components/label/Label";
import { Input } from "../components/input";
import { useForm } from "react-hook-form";
import FromGroup from "../components/common/FromGroup";
import { Checkbox } from "../components/checkbox";
import Button from "../components/button/Button";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import IconEyeToggle from "../components/icons/IconEyeToggle";
import useToggleValue from "../hooks/useToggleValue";
import authService from "../services/auth.service";
import { toast } from "react-toastify";

const schema = yup.object({
  name: yup.string().required("This field is required"),
  email: yup
    .string()
    .email("Invalid email address")
    .required("This field is required"),
  password: yup
    .string()
    .required("This field is required")
    .min(8, "Password must be 8 character "),
});
const SignUpPage = () => {
  const navigate = useNavigate();
  const {
    handleSubmit,
    control,
    formState: { errors,isSubmitting },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onSubmit",
  });
  const handleSignUp = async (values) => {
    const signUpModel = {
      username: values.name,
      password: values.password,
      displayname: "string",
      mobile: "string",
      email: values.email,
      createdBy: "dev",
    };
    try {
      await authService.userAPI.signup(signUpModel).then(() => {
        toast.success("Đăng ký thành công");

        navigate("/sign-in");
        window.location.reload();
      });
    } catch (err) {
      toast.error("Username hoặc password đã tồn tại");
      console.log(err);
    }
  };
  const { value: acceptTerm, handleToggleValue: handleToggleTerm } =
    useToggleValue();
  const { value: showPassword, handleToggleValue: handleTogglePassword } =
    useToggleValue();
  return (
    <LayoutAuthentication heading="SignUp">
      <p className="mb-6 text-xs font-normal text-center lg:text-sm text-text3 lg:mb-8">
        Already have an account?{" "}
        <Link to="/sign-in" className="font-medium underline text-primary">
          Sign in
        </Link>
      </p>
      <button className="flex items-center justify-center w-full py-4 mb-5 text-base font-semibold border gap-x-3 border-strock rounded-xl text-text2 dark:text-white dark:border-darkStroke">
        <img srcSet="/google.png 2x" alt="icon-google" />
        <span>Sign up with google</span>
      </button>
      <p className="text-center mb-4 text-xs lg:text-sm text-text2 lg:mb-8 font-normal">
        Or sign up with username
      </p>
      <form onSubmit={handleSubmit(handleSignUp)}>
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
          <Label htmlFor="email">Email *</Label>
          <Input
            control={control}
            name="email"
            type="email"
            placeholder="example@gmail.com"
            error={errors.name?.message}
          ></Input>
        </FromGroup>
        <FromGroup>
          <Label htmlFor="password">Password *</Label>
          <Input
            control={control}
            name="password"
            type={`${showPassword ? "text" : "password"}`}
            placeholder="Create password"
            error={errors.name?.message}
          >
            <IconEyeToggle
              open={showPassword}
              onClick={handleTogglePassword}
            ></IconEyeToggle>
          </Input>
        </FromGroup>
        <div className="flex items-start mb-5 gap-x-5">
          <Checkbox name="term" checked={acceptTerm} onClick={handleToggleTerm}>
            <p className="flex-1 text-xs lg:text-sm text-text2 dark:text-text3">
              I agree to the
              <span className="underline text-secondary">
                {" "}
                Terms of Use
              </span>{" "}
              and have read and understand the
              <span className="underline text-secondary"> Privacy policy.</span>
            </p>
          </Checkbox>
        </div>
        <Button className="w-full" kind="primary" type="submit" isLoading={isSubmitting}>
          Create my account
        </Button>
      </form>
    </LayoutAuthentication>
  );
};

export default SignUpPage;
