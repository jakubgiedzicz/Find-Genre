import "@mantine/core/styles.css";
import { AppShell, createTheme, Group, Text, useMantineTheme, virtualColor } from "@mantine/core";
import { Link, Outlet } from "react-router-dom";
import LightDarkModeButton from "./Components/LightDarkModeButton/LightDarkModeButton";

function App() {
   const mantineTheme = useMantineTheme()
    return (
      <AppShell header={{ height: 60 }} padding="md" w="100dvw">
        <AppShell.Header>
          <Group h="100%" px="md" justify="space-between">
            <Group>
              <Link to="/">
                <Text>Logo</Text>
              </Link>
              <Link to="/genre-details">
                <Text>Details</Text>
              </Link>
              <Link to="/search-by-tag">
                <Text>API</Text>
              </Link>
            </Group>
            <LightDarkModeButton />
          </Group>
        </AppShell.Header>
        <AppShell.Main w="100%">
          <Outlet />
        </AppShell.Main>
      </AppShell>
  );
}

export default App;
