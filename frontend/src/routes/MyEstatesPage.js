import Header from "../components/Header";
import Listing from "../components/Listing";

export default function Estate(){

    return(
        <>
          <Header/>
          <Listing myEstates={true} /> 
          {/* here give the id for requesting backend */}
        </>
    );
}