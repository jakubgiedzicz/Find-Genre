import { Button } from "@mantine/core";
import { Form } from "react-router-dom";
interface props {
    include: string|undefined,
    exclude: string|undefined
}
function SearchForm({ include, exclude }: props) {
  return (
      <Form action={"/search"} name={"q"} method={"get"}>
          {include && <input name="include" type="text" hidden={true} value={include} readOnly />}
          {exclude && < input name="exclude" type="text" hidden={true} value={exclude} readOnly />}
          <Button type={"submit"} px={64} variant="filled" color="indigo" mt={16}>Find genres</Button>
      </Form>
  );
}

export default SearchForm;