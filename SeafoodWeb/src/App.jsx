import { Route, Routes } from "react-router-dom";
import { Suspense, lazy } from "react";
const SignUpPage = lazy(() => import("./pages/SignUpPage"));
const SignInPage = lazy(() => import("./pages/SignInPage"));
const DashBoardPage = lazy(() => import("./pages/DashBoardPage"));
const CategoryAddNew = lazy(()=>import("./modules/category/CategoryAddNew"))
const App = () => {
  return (
    <Suspense>
      <Routes>
        <Route path="/" element={<DashBoardPage></DashBoardPage>}></Route>
        <Route path="/sign-up" element={<SignUpPage></SignUpPage>}></Route>
        <Route path="/sign-in" element={<SignInPage></SignInPage>}></Route>
        <Route path="/manage/add-category" element={<CategoryAddNew></CategoryAddNew>}></Route>
      </Routes>
    </Suspense>
  );
};

export default App;
