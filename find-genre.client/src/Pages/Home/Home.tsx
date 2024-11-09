import { Autocomplete, Box, Button, Divider, Flex, Grid, InputBase, Pill, Stack, Text, Title } from "@mantine/core";
import { useEffect, useState } from "react";
import { MagnifyingGlassIcon } from "@radix-ui/react-icons";
import classes from './Home.module.css'
interface ITagData {
    value: string,
    disabled: boolean,
}
interface ITagState extends ITagData {
    id: number
}

function Home() {
    const icon = <MagnifyingGlassIcon />
    const [count, setCount] = useState(1)
    const [value, setValue] = useState('');
    const [required, setRequired] = useState<ITagState[]>([]);
    const [optional, setOptional] = useState<ITagState[]>([]);
    const [exclude, setExclude] = useState<ITagState[]>([]);
    const tagsL = ['dark', 'electronic', 'choir', 'popular', 'niche', 'club', 'solitude', 'tiktok', 'fast', 'slow', 'cheerful', 'old', 'classic', 'western', 'korean', 'european']
    const [dataR, setDataR] = useState<ITagData[]>([
        { value: 'React', disabled: false },
        { value: 'Angular', disabled: false },
        { value: 'Vue', disabled: false },
        { value: 'Svelte', disabled: false },
    ])

    /*Add new object to required array, update bool value in dataR*/
    const handleOptionSubmit = (val: string) => {
        setRequired([...required, { value: val, disabled: true, id: count }])
        setDataR(dataR.map(x => {
            if (x.value === val) {
                return { ...x, disabled: true }
            } else {
                return x
            }
        }))
        setCount(count + 1)
    }
    /*Clear input field on submit after 350ms*/
    useEffect(() => {
        setTimeout(() =>
            setValue('')
        , 350)
    }, [required])
    return (
        <>
            <Stack pt='4em'>
                <Box>
                    <Title ta='center'>Search by tags</Title>
                    <Text ta='center'>Type in words that describe the music you're looking for</Text>
                </Box>
                <Flex justify='center' align='center'>
                    <Autocomplete data={dataR} value={value} onChange={setValue} limit={3} classNames={{ root: classes.root }} variant='filled' size='xl' radius='xl' aria-label='Search genre by tags' rightSection={icon} onOptionSubmit={(value) => handleOptionSubmit(value)} />
                </Flex>
                <Flex w='100%' justify='center'>
                    <Grid pt='8em' w='75%'>
                        <Grid.Col span={4}>
                            <Title order={2} ta='center'>Required</Title>
                            <Divider my='md' />
                            <InputBase component="div" multiline>
                                <Pill.Group>
                                    {/*Filter out selected element out of required, set update bool on the same element in dataR*/}
                                    {required.map((element) => <Pill size='xl' onRemove={() => { setRequired(required.filter(x => { return x.id != element.id })); setDataR(dataR.map(x => { if (x.value === element.value) { return { ...x, disabled: false } } else { return x } })) }} key={element.id} withRemoveButton>{element.value}</Pill>)}
                                </Pill.Group>
                            </InputBase>
                        </Grid.Col>
                        <Divider orientation='vertical' />
                        <Grid.Col span={3}>
                            <Title order={2} ta='center'>Optional</Title>
                            <Divider my='md' />
                            <InputBase component="div" multiline>
                                <Pill.Group>
                                    {optional.map((element) => <Pill size='xl' key={element.id} withRemoveButton>{element.value}</Pill>)}
                                </Pill.Group>
                            </InputBase>
                        </Grid.Col>
                        <Divider orientation='vertical' />
                        <Grid.Col span={4}>
                            <Title order={2} ta='center'>Exclude</Title>
                            <Divider my='md' />
                            <InputBase component="div" multiline>
                                <Pill.Group>
                                    {exclude.map((element) => <Pill size='xl' key={element.id} withRemoveButton>{element.value}</Pill>)}
                                </Pill.Group>
                            </InputBase>
                        </Grid.Col>
                    </Grid>
                </Flex>
            </Stack>
        </>
    );
}

export default Home;