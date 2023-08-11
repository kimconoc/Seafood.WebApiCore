import Table from 'react-bootstrap/Table';
import { useEffect, useState } from 'react';
import axios from 'axios';
const TableCategoies = () => {
    const [listUser,setListUser] = useState([]);
    useEffect( ()=>{
      const fetchData = async ()=>{
        const resp = await axios.get("http://localhost:5678/api/Category/getList");
       console.log(resp);
       if(resp&&resp.data){
        setListUser(resp.data)
         console.log(listUser);

      }
      }
      fetchData();
    },[])
    return (
        <Table striped bordered hover>
        <thead>
          <tr>
            <th>ID</th>
            <th> Name</th>
            <th>Code</th>
          </tr>
        </thead>
        <tbody>
        {listUser && listUser.length > 0 && listUser.map((item)=>{
          return(
            <tr key={item.id}>
            <td>{item.id}</td>
            <td>{item.name}</td>
            <td>{item.code}</td> 
          </tr>
          )
        })}
          
        
        </tbody>
      </Table>
    );
};

export default TableCategoies;