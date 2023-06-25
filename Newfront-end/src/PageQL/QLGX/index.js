import { useEffect, useState } from "react";
import {
  EditOutlined,
  DeleteOutlined,
  ExclamationCircleFilled,
} from "@ant-design/icons";
import React from 'react';
import { Breadcrumb, Layout, Menu, theme } from "antd";
import { Space,Button,Table,Modal,Status, message} from 'antd';
import axios from "axios";
import ModalGuiXe from "./modal";
import { TeamOutlined } from "@ant-design/icons";
const{ Content } =Layout; 
const { confirm } = Modal;


function QL_GuiXe(props){
  const[DanhSachGuiXe, setDanhSachGuiXe] = useState();
  const [visibleModal, setvisibleModal] = useState(false);
  const[Action,setAction]=useState();
  const [DataEdit,setDataEdit]= useState();
  async function getDanhSachGuiXe(){
    await axios  
    .get("https://localhost:7188/api/v1/GuiXe/DanhSach")
    .then((res) =>{
      const dataGuiXe = res.data.Data;
      setDanhSachGuiXe(dataGuiXe);
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function themMoiXe(dataGuiXe){
    await axios  
    .post("https://localhost:7188/api/v1/GuiXe/ThemMoi",dataGuiXe)//link api them mới xe
    .then((res) =>{
        if(res.data.Status=1){
          message.success(res.data.Message)
        }
        else{
          message.error(res.data.Message)
        }
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function suaXe(dataGuiXe){
    await axios  
    .post("https://localhost:7188/api/v1/GuiXe/CapNhat",dataGuiXe)//link api sua sinh viên
    .then((res) =>{
        if(res.data.Status=1){
          message.success(res.data.Message)
        }
        else{
          message.error(res.data.Message)
        }
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function xoaXe(MaSV){
    await axios  
    .post(`https://localhost:7188/api/v1/GuiXe/Xoa?MaSV=${MaSV}`)//link api xoa sinh viên
    .then((res) =>{
        if(res.data.Status=1){
          message.success(res.data.Message);
           getDanhSachGuiXe();
        }
        else{
          message.error(res.data.Message)
        }
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  useEffect(() =>{
    getDanhSachGuiXe();
  }, []);
  const columns = [
    {
      title:'STT',
      render:(_,record,index)=>index+1,
    },
    {
      title: "Mã Sinh Viên",
      dataIndex: "MaSV",
    },
    {
      title: "Loại Xe",
      dataIndex: "LoaiXe",
    },
    {
      title: "Biển Số Xe",
      dataIndex: "Bien",
    },
    {
      title: "Thao tác",
      align: "center",
      border: "1px solid #f0f0f0",
      width: "100px",
      render: (_, record) => renderThaoTac(record),
     }
  ];

  function renderThaoTac(record) {
    return (
      <div>
        <EditOutlined
          style={{ fontSize: "18px", cursor: "pointer", marginRight: "10px" }}
          onClick={()=> showEdit(record)}
        />
        <DeleteOutlined
          style={{ fontSize: "18px", cursor: "pointer" }}
          onClick={() => showDeleteConfirm(record.id_GX)}
        />
      </div>
    );
  }
  function showAdd(){
    setvisibleModal(true);
    setAction("add");
    setDataEdit(null)
  }
  function showEdit(record){
    setvisibleModal(true);
    setAction("edit");
    setDataEdit(record);
  }
  function showDeleteConfirm(MaSV){
    confirm({
      title:"Cảnh Báo",
      icon:<ExclamationCircleFilled />,
      content:"Bạn có muốn xóa bản ghi này",
      okText:"Có",
      cancelText:"Không",
      onOk(){
        xoaXe(MaSV);
      },
    });
  }
  function hiddenModal(){
    setvisibleModal(false);
  }
  async function Save(dataGuiXe){
    //kiểm tra action == add thì thực hiện gọi api  thêm mới
if(Action=="add"){
   await themMoiXe(dataGuiXe);
}
    //kiểm tra action == edit thì thực hiện gọi api  sửa
    else{
   await suaXe(dataGuiXe);
    }
    await getDanhSachGuiXe();
  }

  return (
    <div>
      <div>
        <Breadcrumb
          style={{
            margin: "16px 0",
          }}
        >
          <div
            style={{
              marginTop: "-56px",
              display: "flex",
              alignItems: "center",
              width: "100%",
              height: "50px",
              background: "white",
              paddingLeft: "10px",
              borderRadius: "5px",
              boxShadow: " 3px 3px 6px #6777EF",
              fontWeight: "bold",
              color: "rgb(103, 119, 239)",
            }}
          >
            <TeamOutlined style={{width:"50px"}}/> QUẢN LÝ GỬI XE
          </div>
        </Breadcrumb>
      </div>
      <div
        style={{
          marginBottom: 16,
        }}
      >
        <Button
          type="primary"
        onClick={() => showAdd()}
        >
          Thêm Mới
        </Button>  
      </div>

      <Table dataSource={DanhSachGuiXe} 
      columns={columns} 
      rowKey={(record) => record.MaSV} bordered 
      />
      <ModalGuiXe 
       visible={visibleModal}
       hiddenModal={hiddenModal}
       action={Action}
       dataEdit={DataEdit}
       save={Save}
       ></ModalGuiXe>
    </div>
  );
};

export default QL_GuiXe;
