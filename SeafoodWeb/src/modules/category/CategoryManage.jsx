import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { useEffect, useState } from "react";
import axios from "axios";
import { ActionDelete, ActionEdit, ActionView } from "../../components/action";
import DashboardHeading from "../dashboard/DashboardHeading";
import { Button } from "../../components/button";

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
  useEffect(() => {
    const fetchData = async () => {
      const resp = await axios.get(
        "https://seafoodapi.azurewebsites.net/api/category/getlist"
      );
      if (resp && resp.data) {
        setListCategory(resp.data);
      }
    };
    fetchData();
  }, []);
  return (
    <div className="w-full max-w-[1440px]">
      <DashboardHeading title="Categories" desc="Manage your category">
        <Button kind="primary" height="60px" href="/manage/add-category">
          Create category
        </Button>
      </DashboardHeading>
      <div className="mb-10 flex justify-end">
        <input
          type="text"
          placeholder="Search category..."
          className="py-4 px-5 border border-gray-300 rounded-lg outline-none"
        />
      </div>
      <div>
        <TableContainer component={Paper}>
          <Table
            sx={{ minWidth: 700, width: 1440 }}
            aria-label="customized table"
          >
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
              {listCategory.map((row) => (
                <StyledTableRow key={row.name}>
                  <StyledTableCell component="th" scope="row">
                    {row.id}
                  </StyledTableCell>
                  <StyledTableCell align="left">{row.name}</StyledTableCell>
                  <StyledTableCell align="left">{row.code}</StyledTableCell>
                  <StyledTableCell>
                    <ActionView></ActionView>
                  </StyledTableCell>
                  <StyledTableCell>
                    <ActionEdit></ActionEdit>
                  </StyledTableCell>
                  <StyledTableCell>
                    <ActionDelete></ActionDelete>
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
