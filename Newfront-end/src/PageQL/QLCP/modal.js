import {React,  useRef, useEffect } from "react";
import { Form, Input, Select, Space } from 'antd';
import { Button, Modal, } from "antd";
function ModalChoPhi(props) {
    const formChiPhi = useRef();//tham chiếu đến form
    useEffect(() => {
      if (props.action == "edit" && props.dataEdit.MaSV)
      //  if (props.action == "edit" && props.dataEdit.MaSV)

     

        formChiPhi.current?.setFieldsValue({ ...props.dataEdit });
      else
        formChiPhi.current?.resetFields();
  
    }, [props.dataEdit]);
    async function onSave() {
        const values = await formChiPhi.current?.validateFields();
        if (values != null) {await props.save(values);}
        await formChiPhi.current?.resetFields();
      };
  return (
<>
<Modal
        
        open={props.visible}
        onOk={onSave}
        title={props.action=="add"?"Thêm Mới Chi Phí ":"Sửa Chi Phí"}

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
         ref={formChiPhi}   //lấy dữ liệu thông qua form
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
            <Form.Item label="Mã Sinh Vien" name="MaSV" hidden>
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
            label="Ngày Đăng Ký"
            name="NgayDK"
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
            label="Ngày Nộp Tiền"
            name="NgayNop"
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

export default ModalChoPhi;