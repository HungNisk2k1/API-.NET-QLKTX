import HeaderPage from "../Header/index";
import MenuPage from "../Menu/index";
import FooterPage from "../Footer/index";
import ContentPage from "../Content/index";

const HomeP = (props)=> {
  return (
    <div>
      <HeaderPage />
      <div style={{ display: "flex" }}>
        <MenuPage />
        <div style={{width:"1900px"}}>
          <ContentPage/>
          <FooterPage />
        </div>
      </div>
    </div>
  );
};
export default HomeP;
