import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { useEffect, useState } from "react";
import { ActionDelete, ActionEdit, ActionView } from "../../components/action";
import DashboardHeading from "../dashboard/DashboardHeading";
import { Button } from "../../components/button";
import { useNavigate } from "react-router-dom";
import authService from "../../services/auth.service";
import { toast } from "react-toastify";
import Swal from "sweetalert2";
import categoryApi from "../../services/CategoriesService";
import { debounce } from "lodash";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));
const CategoryManage = () => {
  const [listCategory, setListCategory] = useState([]);
  const [filter,setFilter] = useState("");
  useEffect(() => {
    const fetchData = async () => {
      const resp = await categoryApi.getAll();
      if (resp && resp.data) {
        setListCategory(resp.data);
      }
      if(filter){
        const filterCategory = await categoryApi.searchByName("/search",filter)
        if(filterCategory && filterCategory.data){
          setListCategory(filterCategory.data)
        }
      }
    };
    fetchData();
  }, [filter]
  );
  const navigate = useNavigate();
  const user = authService.getCurrentUser();
  const handleInputFilter =debounce((e)=>{
      setFilter(e.target.value)
  },500)
  const handleDeleteCategory = (id) => {
    user.role == "Admin"
      ? Swal.fire({
          title: "Are you sure?",
          text: "You won't be able to revert this!",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, delete it!",
        }).then(async (result) => {
          if (result.isConfirmed) {
            try {
              await categoryApi.delete(id);
              Swal.fire("Deleted!", "Your file has been deleted.", "success");
              window.location.reload();
            } catch (err) {
              authService.logout();
              navigate("/sign-in");
            }
          }
        })
      : toast.error("Bạn cần có quyền admin");
  };
  return (
    <div className="w-full">
      <DashboardHeading title="Categories" desc="Manage your category">
        <Button
          kind="ghost"
          height="60px"
          onClick={() => {
            user.role == "Admin"
              ? navigate("/add-category")
              : toast.error("Bạn cần có quyền admin");
          }}
        >
          Create category
        </Button>
      </DashboardHeading>
      <div className="mb-10 flex justify-end">
        <input
          type="text"
          placeholder="Search category..."
          className="py-4 px-5 border border-gray-300 rounded-lg outline-none"
          onChange={handleInputFilter}
        />
      </div>
      <div>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 700 }} aria-label="customized table">
            <TableHead>
              <TableRow>
                <StyledTableCell>ID</StyledTableCell>
                <StyledTableCell align="left">Name</StyledTableCell>
                <StyledTableCell align="left">Code</StyledTableCell>
                <StyledTableCell align="left">Watch</StyledTableCell>
                <StyledTableCell align="left">Edit</StyledTableCell>
                <StyledTableCell align="left">Delete</StyledTableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {listCategory.map((category) => (
                <StyledTableRow key={category.id}>
                  <StyledTableCell component="th" scope="row">
                    {category.id}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {category.name}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {category.code}
                  </StyledTableCell>
                  <StyledTableCell>
                    <ActionView></ActionView>
                  </StyledTableCell>
                  <StyledTableCell>
                    <ActionEdit
                      onClick={() => {
                        if (user.role == "Admin") {
                          navigate(`/update-category?id=${category.id}`);
                        } else {
                          toast.error("Bạn cần có quyền admin");
                        }
                      }}
                    ></ActionEdit>
                  </StyledTableCell>
                  <StyledTableCell>
                    <ActionDelete
                      onClick={() => {
                        handleDeleteCategory(category.id);
                      }}
                    ></ActionDelete>
                  </StyledTableCell>
                </StyledTableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </div>
    </div>
  );
};

export default CategoryManage;
