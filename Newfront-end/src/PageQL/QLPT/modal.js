import {React,  useRef, useEffect } from "react";
import { Form, Input, Select, Space } from 'antd';
import { Button, Modal, } from "antd";
function ModalPhongTro(props) {
    const formPhongTro = useRef();//tham chiếu đến form
    useEffect(() => {
      if (props.action == "edit" && props.dataEdit.id_Phong)
        formPhongTro.current?.setFieldsValue({ ...props.dataEdit });
      else
        formPhongTro.current?.resetFields();
  
    }, [props.dataEdit]);
    async function onSave() {
        const values = await formPhongTro.current?.validateFields();
        if (values != null) {await props.save(values);}
        await formPhongTro.current?.resetFields();
      };
  return (
<>
<Modal
        
        open={props.visible}
        onOk={onSave}
        title={props.action=="add"?"Thêm Mới Phòng Trọ ":"Sửa Thông Tin Phòng Trọ"}

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
         ref={formPhongTro}   //lấy dữ liệu thông qua form
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
            <Form.Item label="ID" name="id_Phong" hidden>
              <Input autoComplete="true" />
            </Form.Item>
          )}
          <Form.Item
            label="ID Phòng"
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
            label="Phòng"
            name="Phong"
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
            label="Giá Phòng"
            name="GiaPhong"
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
            label="Trạng Thái"
            name="TrangThai"
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

export default ModalPhongTro;