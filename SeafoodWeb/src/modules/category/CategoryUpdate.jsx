import FromGroup from "../../components/common/FromGroup";
import { useForm } from "react-hook-form";
import categoryApi from "../../services/CategoriesService";
import { toast } from "react-toastify";
import DashboardHeading from "../dashboard/DashboardHeading";
import Label from "../../components/label/Label";
import { Button } from "../../components/button";
import { Input } from "../../components/input";
import { useSearchParams } from "react-router-dom";
import { useEffect } from "react";

const CategoryUpdate = () => {
  const { control, handleSubmit, reset } = useForm({
    mode: "onChange",
    defaultValues: {
      name: "",
      code: "",
      icon: "",
    },
  });
  const [params] = useSearchParams();
  const categoryId = params.get("id");

  useEffect(() => {
    async function featchData() {
      const slug = "/getcategorybyid";
      const data = await categoryApi.getById(slug, categoryId);

      reset({
        name: data.data.name,
        code: data.data.code,
        icon: data.data.icon,
      });
    }
    featchData();
  }, [categoryId, reset]);
  const handleUpdate = async (values) => {
    const CategoryModel = {
      name: values.name,
      code: values.code,
      icon: values.icon,
    };
    try {
      await categoryApi.update(categoryId, CategoryModel).then(() => {
        toast.success("successfully");
      });
    } catch (err) {
      toast.error("Update không thành công");
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
        title="Update category"
        desc="Update category"
      ></DashboardHeading>
      <form onSubmit={handleSubmit(handleUpdate)}>
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
          Update category
        </Button>
      </form>
    </div>
  );
};

export default CategoryUpdate;
