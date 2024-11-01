import { ActionIcon, useComputedColorScheme, useMantineColorScheme } from '@mantine/core';
import { MoonIcon, SunIcon } from '@radix-ui/react-icons';

function LightDarkModeButton() {
    const { colorScheme, toggleColorScheme } = useMantineColorScheme();
    const computedColorScheme = useComputedColorScheme('light');
    return (
        <>
            <ActionIcon
                variant="outline"
                color={computedColorScheme === 'dark' ? 'yellow' : 'blue'}
                onClick={() => toggleColorScheme()}
                title="Toggle color scheme"
            >
                {computedColorScheme === 'dark' ? (
                    <SunIcon style={{ width: 18, height: 18 }} />) : <MoonIcon style={{ width: 18, height: 18 }} />}
            </ActionIcon>
        </>
    );
}

export default LightDarkModeButton;