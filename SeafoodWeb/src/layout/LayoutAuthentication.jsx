import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import { withErrorBoundary } from "react-error-boundary";
import ErrorComponent from "../components/common/ErrorComponent";
const LayoutAuthentication = (props) => {
  const { children, heading = "" } = props;
  return (
    <div className="relative w-full min-h-screen p-10 bg-lite dark:bg-darkbg isolate">
      <img
        className="hidden lg:block absolute bottom-0 left-0 right-0 z-[-1]"
        src="/bg.png"
        alt="bg"
      ></img>
      <Link to="/" className="inline-block mb-5 lg:mb-10">
        <img srcSet="/logo.png 2x" alt="seafood"></img>
      </Link>
      <div className="w-full max-w-[556px] bg-white rounded-xl px-5 py-5 lg:px-16 lg:py-12 mx-auto">
        <h1 className="text-text1 text-center font-bold text-lg mb-1 lg:text-xl lg:mb-3">
          {heading}
        </h1>
        {children}
      </div>
    </div>
  );
};
LayoutAuthentication.propTypes = {
  heading: PropTypes.string,
  children: PropTypes.node,
};
export default withErrorBoundary(LayoutAuthentication, {
  FallbackComponent: ErrorComponent,
});
