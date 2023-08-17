import CategoryManage from "../modules/category/CategoryManage";
import DashboardSidebar from "../modules/dashboard/DashboardSidebar";
import DashboardTopBar from "../modules/dashboard/DashboardTopBar";

const LayoutDashboard = () => {
    return (
        <div className="p-10 bg-lite min-h-screen">
            <DashboardTopBar></DashboardTopBar>
            <div className="flex gap-x-10">
                <DashboardSidebar></DashboardSidebar>
                <div>
                  <CategoryManage></CategoryManage>
                </div>
            </div>
        </div>
    );
};

export default LayoutDashboard;