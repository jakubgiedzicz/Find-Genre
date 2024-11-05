import '@mantine/core/styles.css'
import { AppShell, Group, MantineProvider } from '@mantine/core';
import { Outlet } from 'react-router-dom';
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
                        <div>Logo</div>
                        <Group h='100%' px="md">
                            <div>Random</div>
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