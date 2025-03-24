import { Card, Text } from "@mantine/core";
import styles from './GenreCardSmall.module.css'
import { useHover } from "@mantine/hooks";

function GenreCardSmall({ title, description }: { title: string, description: string }) {
    const { hovered, ref } = useHover()
    return (
        <Card shadow="md" className={styles.similar_card} ref={ref}>
            <Text size="xl" fw={500}>{title}</Text>
            <Text size="lg" lineClamp={hovered?10:3}>
                {description}
            </Text>
        </Card>
    );
}

export default GenreCardSmall;