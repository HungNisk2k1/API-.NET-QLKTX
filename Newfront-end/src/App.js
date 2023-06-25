import{ React, useState,useEffect } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import {useLocation,Navigate, Outlet} from "react-router-dom";
import Home from "./TrangChu/Home/index";
import Mylogin from "./LOGIN/index";
import Sinhvien from "./PageQL/QLSV";
import Phongtro from "./PageQL/QLPT";
import Tientro from "./PageQL/QLCP";
import Guixe from "./PageQL/QLGX";
import Hotro from "./PageQL/YCHT";
import Taikhoan from "./PageQL/TTTK";


function App() {
  const CheckLogin=()=>{
    const {thislocation}=useLocation();
    const[IsLogin,setIsLogin]=useState();
    useEffect(()=>{
let LoginCheck =localStorage.getItem("LoginQLKTXCheck");

setIsLogin(LoginCheck);}
, [thislocation]);
  if(IsLogin===undefined){
    return null;
  }
  return IsLogin? <Outlet />:<Navigate to="/login" replace />;
   };
  return (
    <div>
      <BrowserRouter>
        <Routes>
        <Route element={<CheckLogin />}>
          <Route path="/" element={<Home />}>
            <Route path="sinh-vien" element={<Sinhvien />}></Route>
            <Route path="phong-tro" element={<Phongtro />}></Route>
            <Route path="tien-tro" element={<Tientro />}></Route>
            <Route path="gui-xe" element={<Guixe />}></Route>
            <Route path="ho-tro" element={<Hotro />}></Route>
            <Route path="tai-khoan" element={<Taikhoan />}></Route>            
          </Route>
          </Route>
          <Route path="login" element={<Mylogin />}></Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}
export default App;
