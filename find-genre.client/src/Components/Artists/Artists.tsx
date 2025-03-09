import { Title, Card, Flex, Image } from "@mantine/core";
import { Link } from "react-router-dom";
import { IArtists } from "../../Types/api";
import bc_light from '../../assets/bandcamp-logotype-light-128.png'
import styles from './Artists.module.css'

function Artists({ artists }: { artists: IArtists[] }) {
    const items = artists.map((i) => {
        (<><Title order={2}>{i.name}</Title>
            <Card>
                {i.spotify && < Card.Section className={styles.spotify_border} p={"1em"}>
                    <iframe src={`https://open.spotify.com/embed/artist/${i.spotify}`} width="100%" height="352" frameBorder="0" allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy"></iframe>
                </Card.Section>}
                {i.bandcamp && < Card.Section className={styles.spotify_border} p={"1em"}>
                    <Flex justify={"center"} align={"center"}>
                        <Link to={`https://${i.bandcamp}.bandcamp.com/`} target={"_blank"}>
                            <Image src={bc_light} width={442} height={128} />
                        </Link>
                    </Flex>
                </Card.Section>}
            </Card>
        </>
        )
    })
    return (
        <>
            <Title order={1}>
                Artists
            </Title>
            {items}
        </>
    );
}

export default Artists;