import { TextInput } from '@mantine/core';
import { MagnifyingGlassIcon } from '@radix-ui/react-icons';

function SearchBar() {
    const icon = <MagnifyingGlassIcon/>
    return (
        <TextInput
            rightSection={icon}
            aria-label="Enter genre name"
            placeholder="Enter genre name"
        />
  );
}

export default SearchBar;