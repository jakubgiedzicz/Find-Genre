import { IGenre } from "../../Types/api";
import { SimpleGrid, Stack } from "@mantine/core";
import { useState } from "react";
import data from '../../data.json'
import GenreCard from '../../Components/GenreCard/GenreCard';
function SearchResult() {
    const [genres, setGenres] = useState<IGenre[]>(data)
    return (
        <Stack mx={"15%"}>
            <SimpleGrid cols={{ base: 1, md: 2, xl: 3 }} mt={32}>
                {genres && genres.map((i) => (
                    <GenreCard data={i} />
                ))}
            </SimpleGrid>
        </Stack>
    );
}

export default SearchResult;