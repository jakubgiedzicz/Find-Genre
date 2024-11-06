import '@mantine/core/styles.css'
import { AppShell, Group, MantineProvider, Text } from '@mantine/core';
import { Link, Outlet } from 'react-router-dom';
import LightDarkModeButton from './Components/LightDarkModeButton/LightDarkModeButton';
import SearchBar from './Components/SearchBar/SearchBar';

function App() {
    return (
        <MantineProvider>
            <AppShell
                header={{ height: 60 }}
                padding='md'>
                <AppShell.Header>
                    <Group h="100%" px="md" justify="space-between">
                        <Group>
                        <Link to="/"><Text>Logo</Text></Link>
                            <Link to="/genre-details"><Text>Details</Text></Link>
                            <Link to="/search-by-tag"><Text>Search</Text></Link>
                        </Group>
                        <Group h='100%' px="md">
                            <Text>Random</Text>
                            <SearchBar />
                        </Group>
                        <LightDarkModeButton />
                    </Group>
                </AppShell.Header>
                <AppShell.Main>
                    <Outlet />
                </AppShell.Main>
            </AppShell>
        </MantineProvider>
    );
}

export default App;