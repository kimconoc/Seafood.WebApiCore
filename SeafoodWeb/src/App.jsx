import { Route, Routes, Navigate } from "react-router-dom";

import { Suspense, lazy } from "react";
import jwt_decode from "jwt-decode";
import authService from "./services/auth.service";
const SignUpPage = lazy(() => import("./pages/SignUpPage"));
const SignInPage = lazy(() => import("./pages/SignInPage"));
const DashBoardPage = lazy(() => import("./pages/DashBoardPage"));
const LayoutDashboard = lazy(() => import("./layout/LayoutDashboard"));
const CategoryAddNew = lazy(() => import("./modules/category/CategoryAddNew"));
const CategoryManage = lazy(() => import("./modules/category/CategoryManage"));
const CategoryUpdate = lazy(() => import("./modules/category/CategoryUpdate"));
const App = () => {
  const user = authService.getCurrentUser();
  if (user == null) {
    return (
      <Suspense>
        <Routes>
          <Route path="/sign-in" element={<SignInPage></SignInPage>}></Route>
          <Route path="/" element={<Navigate replace to="/sign-in" />} />
          <Route path="/sign-up" element={<SignUpPage></SignUpPage>}></Route>
          <Route path="/home" element={<DashBoardPage></DashBoardPage>}></Route>
          <Route element={<LayoutDashboard></LayoutDashboard>}>
            <Route
              path="/add-category"
              element={<CategoryAddNew></CategoryAddNew>}
            ></Route>
            <Route
              path="/category"
              element={<CategoryManage></CategoryManage>}
            ></Route>
            <Route
              path="/update-category"
              element={<CategoryUpdate></CategoryUpdate>}
            ></Route>
          </Route>
        </Routes>
      </Suspense>
    );
  } else {
    const decoded = jwt_decode(user.token);
    const exp = decoded.exp;
    const currentTimeInSeconds = Math.floor(Date.now() / 1000);
    if (currentTimeInSeconds >= exp) {
      localStorage.removeItem("user");
      return (
        <Suspense>
          <Routes>
            <Route path="/sign-in" element={<SignInPage></SignInPage>}></Route>
            <Route path="/" element={<Navigate replace to="/sign-in" />} />
            <Route path="/sign-up" element={<SignUpPage></SignUpPage>}></Route>
            <Route
              path="/home"
              element={<DashBoardPage></DashBoardPage>}
            ></Route>
            <Route element={<LayoutDashboard></LayoutDashboard>}>
              <Route
                path="/add-category"
                element={<CategoryAddNew></CategoryAddNew>}
              ></Route>
              <Route
                path="/category"
                element={<CategoryManage></CategoryManage>}
              ></Route>
              <Route
                path="/update-category"
                element={<CategoryUpdate></CategoryUpdate>}
              ></Route>
            </Route>
          </Routes>
        </Suspense>
      );
    } else {
      return (
        <Suspense>
          <Routes>
            <Route
              path="/home"
              element={<DashBoardPage></DashBoardPage>}
            ></Route>
            <Route path="/" element={<Navigate replace to="/home" />} />

            <Route element={<LayoutDashboard></LayoutDashboard>}>
              <Route
                path="/add-category"
                element={<CategoryAddNew></CategoryAddNew>}
              ></Route>
              <Route
                path="/category"
                element={<CategoryManage></CategoryManage>}
              ></Route>
              <Route
                path="/update-category"
                element={<CategoryUpdate></CategoryUpdate>}
              ></Route>
            </Route>
          </Routes>
        </Suspense>
      );
    }
  }
};

export default App;
