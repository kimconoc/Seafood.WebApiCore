import { Link } from "react-router-dom";
import LayoutAuthentication from "../layout/LayoutAuthentication";
import Label from "../components/label/Label";
import { Input } from "../components/input";
import { useForm } from "react-hook-form";
import FromGroup from "../components/common/FromGroup";
import { FormGroup } from "react-bootstrap";
import { Checkbox } from "../components/checkbox";
import Button from "../components/button/Button";

const SignUpPage = () => {

    const {
        control,
      } = useForm({
        mode: "onSubmit",
      });
  return (
    <LayoutAuthentication heading="SignUp">
     <p className="mb-6 text-xs font-normal text-center lg:text-sm text-text3 lg:mb-8">Already have an account?{" "}<Link className="font-medium underline text-primary">Sign in</Link></p>
     <button className="flex items-center justify-center w-full py-4 mb-5 text-base font-semibold border gap-x-3 border-strock rounded-xl text-text2 dark:text-white dark:border-darkStroke">
        <img srcSet="/google.png 2x" alt="icon-google" />
        <span>Sign up with google</span>
      </button>
      <p className="text-center mb-4 text-xs lg:text-sm text-text2 lg:mb-8 font-normal">Or sign up with username</p>
      <form>
        <FromGroup>
          <Label htmlFor="name">Full Name *</Label>
          <Input
            control={control}
            name="name"
            placeholder="Jhon Doe" 
          ></Input>
        </FromGroup>
        <FormGroup>
          <Label htmlFor="email">Email *</Label>
          <Input
            control={control}
            name="email"
            type="email"
            placeholder="example@gmail.com"
          ></Input>
        </FormGroup>
        <FormGroup>
          <Label htmlFor="password">Password *</Label>
          <Input
            control={control}
            name="password"
            type="password"
            placeholder="Create password"
          ></Input>
        </FormGroup>
        <div className="flex items-start mb-5 gap-x-5">
          <Checkbox name="term">
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
        <Button className="w-full" kind="primary" type="submit" >
          Create my account
        </Button>
      </form>
    </LayoutAuthentication>
  );
};

export default SignUpPage;
