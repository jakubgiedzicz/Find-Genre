import { Link, useNavigate, useSearchParams } from "react-router-dom";
import { IGenre } from "../../Types/api";
import styles from './SearchResult.module.css'
import { Badge, Button, Card, Center, Group, SimpleGrid, Stack, Text, Title, useComputedColorScheme } from "@mantine/core";
import { useState } from "react";
import data from '../../data.json'
function SearchResult() {
    const [searchParams, setSearchParams] = useSearchParams()
    const [genres, setGenres] = useState<IGenre[]>(data)
    const scheme = useComputedColorScheme()
    const navigate = useNavigate()
    const getTags = () => {
        return genres[0].tags.map((e) => {
            if (searchParams.get("include")?.split(" ").includes(e.name)) {
                return (<Badge key={e.tagId} color="green" variant={scheme == "dark" ? "light" : "filled"}>{e.name}</Badge>)
            } else return (<Badge key={e.tagId} color="indigo" variant={scheme == "dark" ? "light" : "filled"}>{e.name}</Badge>)
        })
    }
    return (
        <Stack mx={"15%"}>
            <SimpleGrid cols={{ base: 1, md: 2, xl: 3 }} mt={32}>
                <Card shadow="md" p={64} className={styles.search_card}>
                    <Card.Section pb={16}>
                        <Title ta="center" order={1} fw={500}>{genres[0].name}</Title>
                        <Text c="dimmed">{genres[0].description_short}</Text>
                    </Card.Section>
                    <Card.Section pb={16}>
                        <Group>
                            {getTags()}
                        </Group>
                    </Card.Section>
                    <Card.Section>
                        <Center>
                            <Button px={64} color="indigo" onClick={() => navigate(`/genre-details/${genres[0].name.toLowerCase()}`, { state: genres[0] } )}>Read more</Button>
                        </Center>
                    </Card.Section>
                </Card>
            </SimpleGrid>
        </Stack>
    );
}

export default SearchResult;