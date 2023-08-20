export default function authHeader() {
  const user = JSON.parse(localStorage.getItem("user"));
  if (user) {
    return {
      headers: {
        Authorization: user.token,
      },
    };
  } else {
    return {};
  }
}

// export default function authHeader() {
//   const user = JSON.parse(localStorage.getItem("user"));

//   if (user && user.accessToken) {
//     // return { Authorization: 'Bearer ' + user.accessToken };
//     return {  headers: {
//       Authorization: user.get("token"),
//     }, };
//   } else {
//     return {};
//   }
// }
