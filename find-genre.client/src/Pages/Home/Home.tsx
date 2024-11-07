import { Autocomplete, Box, Flex, Grid, Stack, Text, Title } from "@mantine/core";
import { useState } from "react";
import { MagnifyingGlassIcon } from "@radix-ui/react-icons";
import classes from './Home.module.css'

function Home() {
    const icon = <MagnifyingGlassIcon />
    const [value, setValue] = useState('');
    const tags = ['dark', 'electronic', 'choir', 'popular', 'niche', 'club', 'solitude', 'tiktok', 'fast', 'slow', 'cheerful', 'old', 'classic', 'western', 'korean', 'european']
    return (
        <>
            <Stack pt='4em'>
                <Box>
                    <Title ta='center'>Search by tags</Title>
                    <Text ta='center'>Type in the words that describe the music you're looking for</Text>
                </Box>
                <Flex justify='center' align='center'>
                    <Autocomplete data={tags} value={value} onChange={setValue} limit={3} classNames={{ root: classes.root }} variant='filled' size='xl' radius='xl' aria-label='Search genre by tags' rightSection={icon} />
                </Flex>
                <Grid pt='8em'>
                    <Grid.Col span={4}>1</Grid.Col>
                    <Grid.Col span={4}>2</Grid.Col>
                    <Grid.Col span={4}>3</Grid.Col>
                </Grid>
            </Stack>
        </>
    );
}

export default Home;