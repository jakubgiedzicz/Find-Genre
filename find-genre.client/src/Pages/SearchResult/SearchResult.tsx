import { IGenre } from "../../Types/api";
import { SimpleGrid, Stack } from "@mantine/core";
import { useEffect, useState } from "react";
import data from '../../data.json'
import GenreCard from '../../Components/GenreCard/GenreCard';
import { useSearchParams } from "react-router-dom";
function SearchResult() {
    const [params, setParams] = useSearchParams()
    const [genres, setGenres] = useState<IGenre[]>()
    const [include, setInclude] = useState(params.get("include")?.split(" "))
    const [exclude, setExclude] = useState(params.get("exclude")?.split(" "))
    //console.log(data.filter((i) => {
    //    params.get("exclude")?.split(" ").forEach((j) => {
    //        if (i.tags.includes(j))
    //    })
    //}))
    const filterGenres = () => {
        const IArray: IGenre[] = []
        const EArray: IGenre[] = []
        data.forEach(i => {
            i.tags.forEach((t) => {
                if (include && include.includes(t.name)) {
                    if (!(IArray.includes(i)))
                        IArray.push(i)
                }
                if (exclude && exclude.includes(t.name)) {
                    if (!(EArray.includes(i)))
                        EArray.push(i)
                }
                return
            })
        })
        const newArray: IGenre[] = []
        if (exclude && exclude.length != 0) {
            IArray.forEach((i) => {
                EArray.forEach((e) => {
                    if (!(i.name == e.name)) {
                        newArray.push(i)
                    }
                }
                )
            })
        }
        if (exclude) { setGenres(newArray) } else setGenres(IArray)
    }
    useEffect(() => {
        filterGenres()
    }, [])
    return (
        <Stack mx={"15%"}>
            <SimpleGrid cols={{ base: 1, md: 2, xl: 3 }} mt={32}>
                {genres && genres.map((i) => (
                    <GenreCard data={i} key={i.genreId} />
                ))}
            </SimpleGrid>
        </Stack>
    );
}

export default SearchResult;