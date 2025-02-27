import { useEffect, useState } from "react";

function SearchByTag() {
  const [data, setData] = useState()
  useEffect(()=> {
    fetch('https://localhost:7252/api/genre').then((res) => {
      return res.json()
    })
    .then((genres) => {
      console.log(genres)
      setData(genres)
    })
  },[])
  return (
      <>
          xdd
      </>
  );
}

export default SearchByTag;