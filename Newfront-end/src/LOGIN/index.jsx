
import {React,useEffect,useState} from 'react'
import { Form, Input, Button, Checkbox,message } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import { useNavigate,useLocation,Navigate } from 'react-router-dom';
import "../LOGIN/Login.css"
import axios from 'axios';
function Mylogin() {
    const {pathname}=useLocation();
    const [IsLogin,setIsLogin] =useState();
    const navigate = useNavigate();
    useEffect(() =>{
        let LoginCheck =localStorage.getItem("LoginQLKTXcheck");
        setIsLogin(LoginCheck)
    },[pathname]);
    function onFinish(values){
        axios
      .post("https://localhost:7188/api/DangNhap/Login", values)
      .then((res) => {
          if (res.data.Status >= 1) {
              let LoginCheckData={
                UserName:res.data.UserName,
                Status:res.data.Status,
              };
              localStorage.setItem("LoginQLKTXCheck",JSON.stringify(LoginCheckData));
              navigate("/");
              message.success(res.data.Message);
          } else {
              message.error(res.data.Message);
          }
      })
      .catch((error) => {
        message.error("lỗi hệ thống , vui lòng liên hệ My để hỗ trợ");
      });
    }
  return IsLogin?(
    <Navigate to="/" replace />):(
    <div className="LoginMainContent">
<div className=" LoginContentWrapper">
<div className="LoginContent">
<div className="TopTextWrapper">ĐĂNG NHẬP</div>
<div className="InputLogin">
    <Form
      name="normal_login"
      className="login-form"
      initialValues={{
        remember: true,
      }}
         autoComplete="off"
         onFinish={onFinish}
    >
    <h2>Tên Tài Khoản</h2>
      <Form.Item
        name="username"
        rules={[
          {
            required: true,
            message: 'Please input your Username!',
          },
        ]}
      >
        <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" 
            className="InputLoginStyle"
        />
      </Form.Item>
      <h2>Mật Khẩu </h2>
      <Form.Item
        name="password"
        rules={[
          {
            required: true,
            message: 'Please input your Password!',
          },
        ]}
      >
        <Input
          prefix={<LockOutlined className="site-form-item-icon" />}
          type="password"
          placeholder="Password"
          className="InputLoginStyle"
        />
      </Form.Item>
      <Form.Item>
        <Form.Item name="remember" valuePropName="checked" noStyle>
          <Checkbox>Remember me</Checkbox>
        </Form.Item>

        <a className="login-form-forgot" href="">
          Forgot password
        </a>
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit" className="login-form-button InputLoginButtonStyle" >
          Log in
        </Button>
        Or <a href="">register now!</a>
      </Form.Item>
    </Form>
    </div>
    </div>
   </div>
  </div>
  );
}

export default Mylogin;