import { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Header from '../components/Header';
function EstatePage() {
  const { id } = useParams();// estate ID


  return(<>
    <Header />
    
    </>
  );
    
}

export default EstatePage;