import {React,  useRef, useEffect } from "react";
import { Form, Input, Select, Space } from 'antd';
import { Button, Modal, } from "antd";
function ModalGuiXe(props) {
    const formGuiXe = useRef();//tham chiếu đến form
    useEffect(() => {
      if (props.action == "edit" && props.dataEdit.MaSV)
        formGuiXe.current?.setFieldsValue({ ...props.dataEdit });
      else
        formGuiXe.current?.resetFields();
  
    }, [props.dataEdit]);
    async function onSave() {
        const values = await formGuiXe.current?.validateFields();
        if (values != null) {await props.save(values);}
        await formGuiXe.current?.resetFields();
      };
  return (
<>
<Modal
        
        open={props.visible}
        onOk={onSave}
        title={props.action=="add"?"Thêm Mới Xe ":"Sửa Thông Tin Xe"}

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
         ref={formGuiXe}   //lấy dữ liệu thông qua form
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
            <Form.Item label="ID" name="id_GX" hidden>
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
            label="Loại xe"
            name="LoaiXe"
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
            label="Biển Số Xe"
            name="Bien"
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

export default ModalGuiXe;