import { Cookies } from "react-cookie";

export default function authHeader() {
  const cookies = new Cookies();
  const token = cookies.get("token");

  if (token) {
    return {
      headers: {
        Authorization: cookies.get("token"),
      },
    };
  } else {
    return {};
  }
}