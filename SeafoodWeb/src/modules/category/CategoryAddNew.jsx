import { useForm } from "react-hook-form";
import { Button } from "../../components/button";
import { Input } from "../../components/input";
import Label from "../../components/label/Label";
import DashboardHeading from "../dashboard/DashboardHeading";
import FromGroup from "../../components/common/FromGroup";
import categoryApi from "../../services/CategoriesService";
import { toast } from "react-toastify";
import authService from "../../services/auth.service";
import { useNavigate } from "react-router-dom";

const CategoryAddNew = () => {
  const navigate = useNavigate();

  const { control, handleSubmit, reset } = useForm({
    mode: "onChange",
    defaultValues: {
      name: "",
      code: "",
      icon: "",
    },
  });
  const handleAddNewCategory = async (values) => {
    const CategoryModel = {
      name: values.name,
      code: values.code,
      icon: values.icon,
    };
    try {
      await categoryApi.create(CategoryModel).then(() => {
        toast.success("Create new category successfully");
      });
    } catch (err) {
      toast.error("Thêm không thành công");
      authService.logout();
      navigate("/sign-in");
      window.location.reload();
    } finally {
      reset({
        name: "",
        code: "",
        icon: "",
      });
    }
  };
  return (
    <div className="w-full">
      <DashboardHeading
        title="New category"
        desc="Add new category"
      ></DashboardHeading>
      <form onSubmit={handleSubmit(handleAddNewCategory)}>
        <div className="mb-20 w-full max-w-[640px] mx-auto">
          <FromGroup>
            <Label>Name</Label>
            <Input
              control={control}
              name="name"
              placeholder="Enter your category name"
            ></Input>
          </FromGroup>
          <FromGroup>
            <Label>Code</Label>
            <Input
              control={control}
              name="code"
              placeholder="Enter your category code"
            ></Input>
          </FromGroup>
          <FromGroup>
            <Label>Icon</Label>
            <Input
              control={control}
              name="icon"
              placeholder="Enter your category icon"
            ></Input>
          </FromGroup>
        </div>
        <Button kind="primary" className="mx-auto w-[260px]" type="submit">
          Add new category
        </Button>
      </form>
    </div>
  );
};

export default CategoryAddNew;
