import { Carousel } from '@mantine/carousel';
import { Stack, Group, Box } from '@mantine/core';
import { IGenre } from '../../Types/api';
import { useLocation } from 'react-router-dom';
import '@mantine/carousel/styles.css';
import json from '../../data.json'
import { useEffect, useState } from 'react';
import Descriptions from '../../Components/Descriptions/Descriptions';
import Artists from '../../Components/Artists/Artists';
import DetailsIntro from '../../Components/DetailsIntro/DetailsIntro';
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
        <Stack mx={'20%'}>
            <Group justify="center" align="center" wrap="nowrap" mt="64" gap="lg">
                {genre && <DetailsIntro name={genre.name} desc={genre.description_short} tags={genre.tags} subgenres={genre?.subgenres} />}
                {genre && <Box w={500} h={400}>
                    <Carousel withIndicators controlSize={40} slideSize="100%" loop>
                        {genre.examples && genre.examples.map((i) => (<Carousel.Slide key={i}><iframe
                            width="500"
                            height="400"
                            frameBorder="0 0 0 0"
                            loading="lazy"
                            src={`https://www.youtube.com/embed/${i}`}
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                            referrerPolicy="strict-origin-when-cross-origin"
                        ></iframe></Carousel.Slide>))}
                    </Carousel>
                </Box>}
            </Group>
            {genre?.descriptions && <Descriptions descs={genre?.descriptions} key={genre.genreId} id={genre.genreId} />}
            {genre?.artists && <Artists artists={genre?.artists} key={genre.genreId} id={genre.genreId} />}
        </Stack>
    );
}

export default GenreDetails;