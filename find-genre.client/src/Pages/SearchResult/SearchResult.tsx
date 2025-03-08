import { useSearchParams } from "react-router-dom";

function SearchResult() {
    const [searchParams, setSearchParams] = useSearchParams()
  return (
    <p>Hello world!</p>
  );
}

export default SearchResult;