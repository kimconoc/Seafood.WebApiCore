import { Route, Routes } from "react-router-dom";
import { Suspense, lazy } from "react";
const SignUpPage = lazy(() => import("./pages/SignUpPage"));
const SignInPage = lazy(() => import("./pages/SignInPage"));
const DashBoardPage = lazy(() => import("./pages/DashBoardPage"));
const LayoutDashboard = lazy(()=>import("./layout/LayoutDashboard"))
const CategoryAddNew = lazy(()=>import("./modules/category/CategoryAddNew"))
const CategoryManage = lazy(()=>import("./modules/category/CategoryManage"))
const App = () => {
  return (
    <Suspense>
      <Routes>
      <Route path="/" element={<DashBoardPage></DashBoardPage>}></Route>
        <Route path="/sign-up" element={<SignUpPage></SignUpPage>}></Route>
        <Route path="/sign-in" element={<SignInPage></SignInPage>}></Route>

        <Route element={<LayoutDashboard></LayoutDashboard>}>
        <Route path="/add-category" element={<CategoryAddNew></CategoryAddNew>}></Route>
        <Route path="/category" element={<CategoryManage></CategoryManage>} ></Route>
        </Route>
      </Routes>
    </Suspense>
  );
};

export default App;
