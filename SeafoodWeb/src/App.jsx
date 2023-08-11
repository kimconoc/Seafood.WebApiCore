
import { Route,Routes } from 'react-router-dom';
import { lazy } from 'react';
const SignUpPage =  lazy(()=>import("./pages/SignUpPage"))
const SignInPage = lazy(()=>import("./pages/SignInPage"))
const App = () => {
    return   <Routes>

        <Route path='/sign-up' element={<SignUpPage></SignUpPage>}></Route> 
        <Route path='/sign-in' element={<SignInPage></SignInPage>}></Route> 
             
     </Routes>
    
};

export default App;
