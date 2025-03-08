import { useSearchParams } from "react-router-dom";

function SearchResult() {
    const [searchParams, setSearchParams] = useSearchParams()
    //array of include tags
    console.log(searchParams.get("include")?.split(" "))
    //array of exclude tags
    console.log(searchParams.get("exclude")?.split(" "))
  return (
    <p>Hello world!</p>
  );
}

export default SearchResult;