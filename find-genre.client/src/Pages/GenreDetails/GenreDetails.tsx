import { Carousel } from '@mantine/carousel';
import { Stack, Group, Title, Box, Badge, Text, useComputedColorScheme, useMantineTheme, Card, Flex, Image } from '@mantine/core';
import styles from '../../Components/SongCard/SongCard.module.css'
import { IGenre } from '../../Types/api';
import { Link, useLocation } from 'react-router-dom';
import '@mantine/carousel/styles.css';
import bc_light from '../../assets/bandcamp-logotype-light-128.png'
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
            {genre?.descriptions && <Descriptions descs={genre?.descriptions} />}
            {genre?.artists && <Artists artists={genre?.artists} />}
        </Stack>
    );
}

export default GenreDetails;