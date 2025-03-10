import { useNavigate, useSearchParams } from "react-router-dom";
import { IGenre } from "../../Types/api";
import styles from './GenreCard.module.css'
import { Badge, Button, Card, Center, Group, Text, Title, useComputedColorScheme } from "@mantine/core";
function GenreCard({ data }: { data: IGenre }) {
    const [searchParams, setSearchParams] = useSearchParams()
    const scheme = useComputedColorScheme()
    const navigate = useNavigate()
    const getTags = () => {
        return data.tags.map((e) => {
            if (searchParams.get("include")?.split(" ").includes(e.name)) {
                return (<Badge key={e.tagId} color="green" variant={scheme == "dark" ? "light" : "filled"}>{e.name}</Badge>)
            } else return (<Badge key={e.tagId} color="indigo" variant={scheme == "dark" ? "light" : "filled"}>{e.name}</Badge>)
        })
    }
    return (
        <Card shadow="md" p={64} className={styles.search_card}>
            <Card.Section pb={16}>
                <Title ta="center" order={1} fw={500}>{data.name}</Title>
                <Text c="dimmed">{data.description_short}</Text>
            </Card.Section>
            <Card.Section pb={16}>
                <Group>
                    {getTags()}
                </Group>
            </Card.Section>
            <Card.Section>
                <Center>
                    <Button px={64} color="indigo" onClick={() => navigate(`/genre-details/${data.name.toLowerCase()}`, { state: data })}>Read more</Button>
                </Center>
            </Card.Section>
        </Card>
    );
}

export default GenreCard;