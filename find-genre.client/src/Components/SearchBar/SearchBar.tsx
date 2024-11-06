import { TextInput } from '@mantine/core';
import { MagnifyingGlassIcon } from '@radix-ui/react-icons';

function SearchBar() {
    const icon = <MagnifyingGlassIcon/>
    return (
        <TextInput
            rightSection={icon}
            aria-label="Search genre by name"
            placeholder="Search genre by name"
        />
  );
}

export default SearchBar;