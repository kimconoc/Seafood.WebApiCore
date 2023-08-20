import PropTypes from "prop-types";

const DashboardHeading = ({ title = "", desc = "", children }) => {
  return (
    <div className="mb-10 flex items-start justify-between">
      <div>
        <h1 className="text-4xl text-primary text-opacity-60 font-bold">
          {title}
        </h1>
        <p className="dashboard-short-desc">{desc}</p>
      </div>
      {children}
    </div>
  );
};
DashboardHeading.propTypes = {
  title: PropTypes.string,
  desc: PropTypes.string,
  children: PropTypes.node,
};
export default DashboardHeading;
