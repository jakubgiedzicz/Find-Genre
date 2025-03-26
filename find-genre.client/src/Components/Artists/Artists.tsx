import { Title, Card, Flex, Image, Box, useComputedColorScheme, Divider } from "@mantine/core";
import { Link } from "react-router-dom";
import { IArtists } from "../../Types/api";
import bc_light from '../../assets/bandcamp-logotype-light-128.png'
import styles from './Artists.module.css'
import bc_dark from '../../assets/bandcamp-logotype-dark-128.png'

function Artists({ artists, id }: { artists: IArtists[], id: number }) {
    const scheme = useComputedColorScheme()
    const items = artists.map((i) =>
    (<Box key={id + i.name}><Box>
        <Title order={2} id={i.name} pl={32} py={8}>{i.name}</Title>
        <Card>
            {i.spotify && < Card.Section className={styles.spotify_border} p={"1em"}>
                <iframe src={`https://open.spotify.com/embed/artist/${i.spotify}`} width="100%" height="352" allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy"></iframe>
            </Card.Section>}
            {i.bandcamp && < Card.Section p={"1em"}>
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