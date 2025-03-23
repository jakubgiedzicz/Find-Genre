import "@mantine/core/styles.css";
import { AppShell, Button, Group, useMantineTheme } from "@mantine/core";
import { Link, Outlet } from "react-router-dom";
import LightDarkModeButton from "./Components/LightDarkModeButton/LightDarkModeButton";

function App() {
    const mantineTheme = useMantineTheme()
    return (
        <AppShell header={{ height: 60 }} padding="md">
            <AppShell.Header>
                <Group h="100%" px="md" justify="space-between">
                    <Group>
                        <Button component={Link} color="indigo" to="/">
                            Home
                        </Button>
                        {/*<Link to="/genre-details">*/}
                        {/*  <Text>Details</Text>*/}
                        {/*</Link>*/}
                        {/*<Link to="/search-by-tag">*/}
                        {/*  <Text>API</Text>*/}
                        {/*</Link>*/}
                    </Group>
                    <LightDarkModeButton />
                </Group>
            </AppShell.Header>
            <AppShell.Main>
                <Outlet />
            </AppShell.Main>
        </AppShell>
    );
}

export default App;
