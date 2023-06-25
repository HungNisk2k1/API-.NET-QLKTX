import {React,  useRef, useEffect } from "react";
import { Form, Input, Select, Space } from 'antd';
import { Button, Modal, } from "antd";
function ModalSinhVien(props) {
    const formSinhVien = useRef();//tham chiếu đến form
    useEffect(() => {
      if (props.action == "edit" && props.dataEdit.MaSV)
        formSinhVien.current?.setFieldsValue({ ...props.dataEdit });
      else
        formSinhVien.current?.resetFields();
  
    }, [props.dataEdit]);
    async function onSave() {
        const values = await formSinhVien.current?.validateFields();
        if (values != null) {await props.save(values);}
        await formSinhVien.current?.resetFields();
      };
  return (
<>
<Modal
        
        open={props.visible}
        onOk={onSave}
        title={props.action=="add"?"Thêm Mới Sinh Viên ":"Sửa Thông Tin Sinh Viên"}

        footer={[
            <Button key="submit" type="primary" onClick={onSave}>
            Lưu
          </Button>,
          <Button danger key="back" type="primary"  onClick={props.hiddenModal}>
            Hủy
          </Button>,
        ]}
      >
       <Form
         ref={formSinhVien}   //lấy dữ liệu thông qua form
          labelCol={{
            span: 6,
          }}
          labelAlign="left"
          wrapperCol={{
            span: 18,
          }}
          initialValues={{
            remember: true,
          }}
          autoComplete="off"
        >
          {props.action == "edit" && (
            <Form.Item label="Mã Sinh Viên" name="MaSV" hidden>
              <Input autoComplete="true" />
            </Form.Item>
          )}
          <Form.Item
            label="Mã Sinh Viên"
            name="MaSV"
            rules={[
              {
                required: true,

                message: "Vui lòng nhập thông tin!",
                autoComplete: "false",
              },
            ]}     
          >       
            <Input autoComplete="true" />
          </Form.Item>
        
      
          <Form.Item
            label="Tên Sinh Viên"
            name="HoTenSV"
            rules={[
              {
                required: true,

                message: "Vui lòng nhập thông tin!",
                autoComplete: "false",
              },
            ]}     
          >       
            <Input autoComplete="true" />
          </Form.Item>
        
          <Form.Item
            label="Ngày Sinh"
            name="NgaySinh"
            rules={[
              {
                required: true,

                message: "Vui lòng nhập thông tin!",
                autoComplete: "false",
              },
            ]}     
          >       
            <Input autoComplete="true" />
          </Form.Item>
        
          <Form.Item
            label="Địa chỉ"
            name="DiaChi"
            rules={[
              {
                required: true,

                message: "Vui lòng nhập thông tin!",
                autoComplete: "false",
              },
            ]}     
          >       
            <Input autoComplete="true" />
          </Form.Item>
        
          <Form.Item
            label="Phòng"
            name="id_Phong"
            rules={[
              {
                required: true,

                message: "Vui lòng nhập thông tin!",
                autoComplete: "false",
              },
            ]}     
          >       
            <Input autoComplete="true" />
          </Form.Item>
      
          <Form.Item
            label="Số điện thoại"
            name="SDT"
            rules={[
              {
                required: true,

                message: "Vui lòng nhập thông tin!", 
                autoComplete: "false",
              },
            ]}     
          >       
            <Input autoComplete="true" />
          </Form.Item>
        </Form>
      </Modal>
</>
  );
};

export default ModalSinhVien;