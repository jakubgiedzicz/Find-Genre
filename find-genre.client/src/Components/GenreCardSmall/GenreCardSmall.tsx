import { Box, Card, Text } from "@mantine/core";
import styles from './GenreCardSmall.module.css'
import { useHover } from "@mantine/hooks";

function GenreCardSmall({ title, description }: { title: string, description: string }) {
    const { hovered, ref } = useHover()
    return (
        <Box className={styles.similar_card}>
            <Card ref={ref}>
                <Text size="xl" fw={500}>{title}</Text>
                <Text size="lg" lineClamp={hovered ? 20 : 3}>
                    {description}
                </Text>
            </Card>
        </Box>
    );
}

export default GenreCardSmall;