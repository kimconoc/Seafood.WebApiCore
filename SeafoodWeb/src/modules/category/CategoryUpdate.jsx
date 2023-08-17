import { Button } from "components/button";
import { Radio } from "components/checkbox";
import { Field } from "components/field";
import { Input } from "components/input";
import { Label } from "components/label";
import DashboardHeading from "module/dashboard/DashboardHeading";
import { categoryStatus } from "utils/constants";
const CategoryUpdate = () => {
  return (
    <div>
      <DashboardHeading
        title="Update category"
        desc={`Update your category id:`}
      ></DashboardHeading>
      <form>
        <div className="form-layout">
          <Field>
            <Label>Name</Label>
            <Input
             
              name="name"
              placeholder="Enter your category name"
            ></Input>
          </Field>
          <Field>
            <Label>Slug</Label>
            <Input
      
              name="slug"
              placeholder="Enter your slug"
            ></Input>
          </Field>
        </div>
        <div className="form-layout">
          <Field>
            <Label>Status</Label>
            <div className="flex flex-wrap gap-x-5">
              <Radio
                name="status"
              
                value={categoryStatus.APPROVED}
              >
                Approved
              </Radio>
              <Radio
                name="status"
              
                value={categoryStatus.UNAPPROVED}
              >
                Unapproved
              </Radio>
            </div>
          </Field>
        </div>
        <Button
          kind="primary"
          className="mx-auto w-[200px]"
          type="submit"
        >
          Update category
        </Button>
      </form>
    </div>
  );
};

export default CategoryUpdate;
