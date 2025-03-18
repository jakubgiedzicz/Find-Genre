import { Stack, Group, Box, Divider, TableOfContents } from '@mantine/core';
import { IGenre } from '../../Types/api';
import { useLocation } from 'react-router-dom';
import '@mantine/carousel/styles.css';
import * as json from '../../data.json'
import { useEffect, useState } from 'react';
import Descriptions from '../../Components/Descriptions/Descriptions';
import Artists from '../../Components/Artists/Artists';
import DetailsIntro from '../../Components/DetailsIntro/DetailsIntro';
import styles from './GenreDetails.module.css'
function GenreDetails() {
    const data = useLocation()
    const [genre, setGenre] = useState<IGenre>(data.state)

    useEffect(() => {
        if (!data.state) {
            const array = json.filter((i) => i.name.toLowerCase() === data.pathname.substring(15).replace("%20", " "))
            setGenre(array[0])
        }
    }, [])
    return (
        <Group wrap="nowrap" align="flex-start" className={styles.genre_details}>
            <TableOfContents
                className={styles.table_of_contents}
                color="indigo"
                radius="sm"
                variant="light"
                minDepthToOffset={0}
                depthOffset={30}
            />
            <Stack>
                <Stack justify="center" align="center" gap="lg">
                    {genre && <DetailsIntro name={genre.name} desc={genre.description_short} tags={genre.tags} subgenres={genre?.subgenres} examples={genre.examples} />}
                </Stack>
                <Divider />
                {genre?.descriptions && <Descriptions descs={genre?.descriptions} key={genre.genreId} id={genre.genreId} />}
                {genre?.artists && <Artists artists={genre?.artists} id={genre.genreId} />}
            </Stack>
        </Group>
    );
}

export default GenreDetails;