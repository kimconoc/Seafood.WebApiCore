import { Outlet } from "react-router-dom";
import DashboardSidebar from "../modules/dashboard/DashboardSidebar";
import DashboardTopBar from "../modules/dashboard/DashboardTopBar";

const LayoutDashboard = () => {
    return (
        <div className="p-10 bg-lite min-h-screen">
            <DashboardTopBar></DashboardTopBar>
            <div className="flex gap-x-10">
                <DashboardSidebar></DashboardSidebar>
                <div className="w-full">
                <Outlet></Outlet>                  
                </div>
            </div>
        </div>
    );
};

export default LayoutDashboard;