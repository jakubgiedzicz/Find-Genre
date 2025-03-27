import { Stack, Group, Divider, TableOfContents, useComputedColorScheme, Breadcrumbs, Anchor, Text, Button, Card, SimpleGrid } from '@mantine/core';
import { IGenre } from '../../Types/api';
import { useLocation } from 'react-router-dom';
import '@mantine/carousel/styles.css';
import json from '../../data.json'
import { useEffect, useState } from 'react';
import Descriptions from '../../Components/Descriptions/Descriptions';
import Artists from '../../Components/Artists/Artists';
import DetailsIntro from '../../Components/DetailsIntro/DetailsIntro';
import styles from './GenreDetails.module.css'
import GenreCardSmall from '../../Components/GenreCardSmall/GenreCardSmall';
function GenreDetails() {
    const data = useLocation();
    const scheme = useComputedColorScheme();
    const [genre, setGenre] = useState<IGenre>(data.state)
    const items = [
        { title: 'Electronic', href: '#' },
        { title: 'Wave', href: '#' },
        { title: 'Witch House', href: '#' },
    ].map((item, index) => (
        <Anchor href={item.href} key={index} c="indigo">
            {item.title}
        </Anchor>))
    useEffect(() => {
        if (!data.state) {
            const array = json.filter((i) => i.name.toLowerCase() === data.pathname.substring(15).replace("%20", " "))
            setGenre(array[0])
        }
    }, [])
    return (
        <>
            <Breadcrumbs separator="→" separatorMargin="sm" className={styles.breadcrumbs + ' ' + styles.margin_inner}>
                {items}
            </Breadcrumbs>
            <Group wrap="nowrap" align="flex-start" className={styles.genre_details + ' ' + styles.margin_inner}>
                <TableOfContents
                    className={styles.table_of_contents}
                    color="indigo"
                    radius="sm"
                    c={scheme === "dark"?"white":"black"}
                    variant={scheme === "dark" ? "light" : "filled"}
                    minDepthToOffset={0}
                    depthOffset={30}
                    getControlProps={({ data }) => ({
                        onClick: () => data.getNode().scrollIntoView(),
                        children: data.value
                    })}
                />
                <Stack>
                    <Stack justify="center" align="center" gap="lg">
                        {genre && <DetailsIntro name={genre.name} desc={genre.description_short} tags={genre.tags} subgenres={genre?.subgenres} examples={genre.examples} />}
                    </Stack>
                    <Divider my={32} />
                    {genre?.descriptions && <Descriptions descs={genre?.descriptions} key={genre.genreId} id={genre.genreId} />}
                    {genre?.artists && <Artists artists={genre?.artists} id={genre.genreId} />}
                    <Text className={styles.similar} mt={32}>More like this</Text>
                    <SimpleGrid cols={{ base: 3, xl: 4 }} mb={32}>
                        <GenreCardSmall title="Wave" description="Wave is a genre of bass music and a visual art style that emerged
              in the early 2010s in online communities. It is characterized
              by atmospheric melodies and harmonies, melodic and heavy bass
              such as reese, modern trap drums, chopped vocal samples processed
              with reverb and delay, and arpeggiators."/>
                        <GenreCardSmall title="Shoegaze" description="Shoegaze (originally called shoegazing and sometimes conflated with dream pop)
                            is a subgenre of indie and alternative rock characterized by its ethereal mixture
                            of obscured vocals, guitar distortion and effects, feedback, and overwhelming volume." />
                        <GenreCardSmall title="Synth-pop" description="Synth-pop (short for synthesizer pop; also called techno-pop) is a music genre
                            that first became prominent in the late 1970s and features the synthesizer as the
                            dominant musical instrument." />
                    </SimpleGrid>
                </Stack>
            </Group>
        </>
    );
}

export default GenreDetails;