import { NavLink } from "react-router-dom";
import IconDarkmode from "../../components/icons/IconDarkmode";
import IconDashboard from "../../components/icons/IconDashboard";
import IconLogout from "../../components/icons/IconLogout";
import IconPayment from "../../components/icons/IconPayment";
import IconProfile from "../../components/icons/IconProfile";
import IconWithdraw from "../../components/icons/IconWithdraw";
import IconCategory from "../../components/icons/IconCategory";
import authService from "../../services/auth.service";
import { useNavigate } from "react-router-dom";

const sidebarLinks = [
  {
    icon: <IconDashboard></IconDashboard>,
    title: "Dashboard",
    url: "/home",
  },
  {
    icon: <IconCategory></IconCategory>,
    title: "Categogy",
    url: "/category",
  },
  {
    icon: <IconPayment></IconPayment>,
    title: "Payment",
    url: "/payment",
  },
  {
    icon: <IconWithdraw></IconWithdraw>,
    title: "Withdraw",
    url: "/withdraw",
  },
  {
    icon: <IconProfile></IconProfile>,
    title: "Profile",
    url: "/profile",
  },
  {
    icon: <IconLogout></IconLogout>,
    title: "Logout",
    url: "/logout",
  },
  {
    icon: <IconDarkmode></IconDarkmode>,
    title: "Light/Dark",
    url: "/#",
    onClick: () => {},
  },
];
const DashboardSidebar = () => {
  const navigate = useNavigate();

  const navlinkClass =
    "flex items-center p-5 gap-x-5  md:h-12 text-icon-color  md:rounded-lg md:mb-8  last:mt-auto last:bg-white last:shadow-sdprimary";
  return (
    <div className="w-full md:w-[300px] rounded-3xl bg-white shadow-[10px_10px_20px_rgba(218,_213,_213,_0.15)] px-[14px] py-10 flex flex-col flex-shrink-0">
      {sidebarLinks.map((link) => {
        if (link.url === "/logout") {
          return (
            <button
              className={navlinkClass}
              key={link.title}
              onClick={() => {
                authService.logout();
                navigate("/sign-in");
                window.location.reload();
              }}
            >
              <span>{link.icon}</span>
              <span>{link.title}</span>
            </button>
          );
        }
        return (
          <NavLink
            to={link.url}
            key={link.title}
            className={({ isActive }) =>
              isActive
                ? `${navlinkClass} text-primary bg-primary bg-opacity-20`
                : `${navlinkClass} text-icon-color`
            }
          >
            <span>{link.icon}</span>
            <span>{link.title}</span>
          </NavLink>
        );
      })}
    </div>
  );
};

export default DashboardSidebar;
