import { Title, Card, Flex, Image, Box, useComputedColorScheme, Group, Stack } from "@mantine/core";
import { Link } from "react-router-dom";
import { IArtists } from "../../Types/api";
import bc_light from '../../assets/bandcamp-logotype-light-128.png'
import styles from './Artists.module.css'
import bc_dark from '../../assets/bandcamp-logotype-dark-128.png'
import sc_light from '../../assets/soundcloud-white.svg'
import sc_dark from '../../assets/soundcloud-black.svg'

function Artists({ artists, id }: { artists: IArtists[], id: number }) {
    const scheme = useComputedColorScheme()
    const items = artists.map((i) =>
    (<Box key={id + i.name}><Box>
        <Title order={2} id={i.name} pl={32} py={8}>{i.name}</Title>
        <Card>
            {i.spotify && < Card.Section className={styles.spotify_border} p={"1em"}>
                <iframe src={`https://open.spotify.com/embed/artist/${i.spotify}`} width="100%" height="352" allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy"></iframe>
            </Card.Section>}
            {(i.bandcamp && i.soundcloud) && < Card.Section p={"1em"} visibleFrom="md">
                <Group wrap="nowrap" justify="space-between">
                    <Link to={`https://${i.bandcamp}.bandcamp.com/`} target={"_blank"}>
                        <Image src={scheme == "dark" ? bc_light : bc_dark} width={442} height={128} loading="lazy" />
                    </Link>
                    <Link to={`https://soundcloud.com/${i.soundcloud}`} target={"_blank"}>
                        <Image src={scheme == "dark" ? sc_light : sc_dark} loading="lazy" />
                    </Link>
                </Group>
            </Card.Section>}
            {(i.bandcamp && i.soundcloud) && < Card.Section p={"1em"} hiddenFrom="md">
                <Stack justify="space-between">
                    <Link to={`https://${i.bandcamp}.bandcamp.com/`} target={"_blank"}>
                        <Image src={scheme == "dark" ? bc_light : bc_dark} width={442} height={128} loading="lazy" />
                    </Link>
                    <Link to={`https://soundcloud.com/${i.soundcloud}`} target={"_blank"}>
                        <Image src={scheme == "dark" ? sc_light : sc_dark} loading="lazy" />
                    </Link>
                </Stack>
            </Card.Section>}
            {(i.bandcamp && !i.soundcloud) && < Card.Section p={"1em"}>
                <Flex justify={"center"} align={"center"}>
                    <Link to={`https://${i.bandcamp}.bandcamp.com/`} target={"_blank"}>
                        <Image src={scheme == "dark" ? bc_light : bc_dark} width={442} height={128} loading="lazy" />
                    </Link>
                </Flex>
            </Card.Section>}
        </Card>
    </Box>
    </Box>
    )
    )
    return (
        <>
            <Title order={1} c={scheme === 'dark' ? 'white' : 'black'}>
                Artists
            </Title>
            {items}
        </>
    );
}

export default Artists;