
import { Button } from "../../components/button";
import DashboardHeading from "../dashboard/DashboardHeading";

const CategoryAddNew = () => {
  return (
    <div>
      <DashboardHeading
        title="New category"
        desc="Add new category"
      ></DashboardHeading>
      
  
        <Button
          kind="primary"
          className="mx-auto w-[200px]"
          type="submit"
        >
          Add new category
        </Button>
      
    </div>
  );
};

export default CategoryAddNew;
